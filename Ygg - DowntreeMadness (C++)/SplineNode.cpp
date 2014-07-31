

#include "DowntreeMadness.h"
#include "SplineNode.h"

/* Default UE4 constructor */
ASplineNode::ASplineNode(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
	// Initialize tangent endpoints to be at the actor location
	this->back = this->GetActorLocation();
	this->front = this->GetActorLocation();

	//Initialize the length of the tangents to 0
	this->backStretchValue = 0;
	this->frontStrechValue = 0;

	// Enable ticking for the actor
	PrimaryActorTick.bCanEverTick = true;
}

void ASplineNode::Tick(float DeltaSeconds)
{
	Super::Tick(DeltaSeconds);
	// Update tangent endpoints according to their rotation and stretch value
	this->front = this->GetActorLocation() + this->frontRotation.Vector() * this->frontStrechValue;
	this->back = this->GetActorLocation() + this->backRotation.Vector() * -(this->backStretchValue);
}




