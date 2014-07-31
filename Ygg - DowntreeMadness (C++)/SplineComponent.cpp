#include "DowntreeMadness.h"
#include "SplineComponent.h"
#include "SplineNode.h"

/* Default UE4 constructor */
ASplineComponent::ASplineComponent(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
	/* Enable ticking */
	PrimaryActorTick.bCanEverTick = true;
	/* Set spline endpoints to be connected (e.g. for circle-courses) */
	this->ConnectEndPoints = false;
}

/* Calculate point on cubic bezier curve defined by four points */
FVector ASplineComponent::CalculatePoint(float t, FVector start, FVector startTangent, FVector endTangent, FVector end)
{
	float u = 1 - t;
	float tt = t * t;
	float uu = u * u;
	float uuu = uu * u;
	float ttt = tt * t;

	FVector p = uuu * start;
	p += 3 * uu * t * startTangent;
	p += 3 * u * tt * endTangent;
	p += ttt * end;

	return p;
}

/* Draw the spline in the viewport by iterating over the respective nodes */
void ASplineComponent::DrawCurve()
{
	ASplineNode* start = *(this->splineNodes.GetTypedData());
	for (TArray<class ASplineNode*>::TIterator iter = this->splineNodes.CreateIterator(); iter; iter++)
	{
		if (start == *iter)
		{
			// Draw a connection between first and last node if ConnectEndPoints is true, else skip to next iteration
			if(!this->ConnectEndPoints) continue;
			ASplineNode* end = this->splineNodes.Last();
			DrawCurveSegment(start->GetActorLocation(), start->front, end->back, end->GetActorLocation());
		}
		else
		{
			ASplineNode* end = *iter;
			DrawCurveSegment(start->GetActorLocation(), start->front, end->back, end->GetActorLocation());
			start = end;
		}
	}
}

/* Draw segment of the spline between two given nodes */
void ASplineComponent::DrawCurveSegment(FVector p0, FVector p1, FVector p2, FVector p3)
{
	float distance = FVector::Dist(p0, p3);
	int32 roundedDistance = (int32)distance;

	FVector start = this->CalculatePoint(0, p0, p1, p2, p3);

	// Draw tangents
	DrawDebugLine(this->GetWorld(), p0, p0 + (p1 - p0) / 2, FColor::Red, false, -1, 0, 8);
	DrawDebugLine(this->GetWorld(), p3, p3 + (p2 - p3) / 2, FColor::Green, false, -1, 0, 8);

	// Draw spline segment
	for (int i = 1; i < roundedDistance; ++i)
	{
		FVector end = CalculatePoint((float)i / distance, p0, p1, p2, p3);
		DrawDebugLine(this->GetWorld(), start, end, FColor::Yellow, false, -1, 0, 10);
		start = end;
	}
}

/* Calculate the total length of the spline */
float ASplineComponent::CalculateSplineLength()
{
	float length = 0;
	ASplineNode* start = *(this->splineNodes.GetTypedData());
	for (TArray<class ASplineNode*>::TIterator iter = this->splineNodes.CreateIterator(); iter; iter++)
	{
		if (start == *iter)
		{
			// Calculate the length between first and last node if ConnectEndPoints is true, else skip to next iteration
			if (!this->ConnectEndPoints) continue;
			ASplineNode* end = this->splineNodes.Last();
			length += CalculateSplineSegmentLength(start, end);
		}
		else
		{
			ASplineNode* end = *iter;
			length += CalculateSplineSegmentLength(start, end);
			start = end;
		}
	}
	return length;
}

/* Calculate the length of a segment of the spline between two given nodes */
float ASplineComponent::CalculateSplineSegmentLength(ASplineNode* first, ASplineNode* second)
{
	float length = 0;
	float distance = FVector::Dist(first->GetActorLocation(), second->GetActorLocation());
	int32 roundedDistance = (int32)distance;

	FVector start = CalculatePoint(0, first->GetActorLocation(), first->front, second->back, second->GetActorLocation());
	for (int i = 1; i < roundedDistance; ++i)
	{
		FVector end = CalculatePoint((float)i / distance, first->GetActorLocation(), first->front, second->back, second->GetActorLocation());
		length += FVector::Dist(start, end);
		start = end;
	}
	return length;
}

/* Called on game start */
void ASplineComponent::BeginPlay()
{
	Super::BeginPlay();
	this->SplineLength = CalculateSplineLength();
}