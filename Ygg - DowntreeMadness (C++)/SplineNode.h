

#pragma once

#include "GameFramework/Actor.h"
#include "SplineNode.generated.h"

/**
 * 
 */
UCLASS()
class ASplineNode : public AActor
{
	GENERATED_UCLASS_BODY()

public:

	// Properties

	FVector back;

	FVector front;

	/* Rotation of the tangent pointing to the last node */
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = SplineNode)
	FRotator backRotation;

	/* Rotation of the tangent pointing to the next node */
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = SplineNode)
	FRotator frontRotation;

	/* Length of the tangent pointing to the last node */
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = SplineNode)
	float backStretchValue;

	/* Length of the tangent pointing to the next node */
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = SplineNode)
	float frontStrechValue;

	// Functions

	void Tick(float DeltaSeconds) OVERRIDE;
};
