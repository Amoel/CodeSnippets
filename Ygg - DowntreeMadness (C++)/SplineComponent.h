#pragma once

#include "GameFramework/Actor.h"
#include "SplineComponent.generated.h"

/**
 * 
 */
UCLASS()
class ASplineComponent : public AActor
{
	GENERATED_UCLASS_BODY()

public:

	// Properties

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = TrackSpline)
	TArray<class ASplineNode*> splineNodes;

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = TrackSpline)
	bool ConnectEndPoints;

	UPROPERTY(BlueprintReadOnly, Category = TrackSpline)
	float SplineLength;

	// Functions

	/* Calculate point on cubic bezier curve defined by four points */
	UFUNCTION(BlueprintCallable, Category = Spline)
	FVector CalculatePoint(float t, FVector p0, FVector p1, FVector p2, FVector p3);

	/* Draw segment of the spline between two given nodes */
	UFUNCTION(BlueprintCallable, Category = Spline)
	void DrawCurveSegment(FVector p0, FVector p1, FVector p2, FVector p3);

	/* Draw the spline in the viewport by iterating over the respective nodes */
	UFUNCTION(BlueprintCallable, Category = Spline)
	void DrawCurve();

	/* Calculate the total length of the spline */
	UFUNCTION(BlueprintCallable, Category = Spline)
	float CalculateSplineLength();

	/* Calculate the length of a segment of the spline between two given nodes */
	UFUNCTION(BlueprintCallable, Category = Spline)
	float CalculateSplineSegmentLength(ASplineNode* start, ASplineNode* end);

	virtual void BeginPlay() OVERRIDE;
};
