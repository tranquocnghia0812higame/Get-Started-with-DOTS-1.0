﻿using System.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;



public readonly partial struct MoveAspect : IAspect
{
    private readonly Entity _entity;
    private readonly TransformAspect _transform;

    private readonly RefRO<TargetPosition> _target;
    private readonly RefRO<Speed> speed;
    private float3 direction => math.normalize(_target.ValueRO.Value - _transform.Position);

    public void Move(float deltaTime)
    {
        _transform.Position += direction * speed.ValueRO.Value * deltaTime;
    }
}