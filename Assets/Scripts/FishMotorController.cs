﻿using System;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;
using UnityTools.Common;
using UnityTools.Debuging;
using UnityTools.Math;
using static UnityFishSimulation.FishSAOptimizer.FishSA;

namespace UnityFishSimulation
{
    [Serializable]
    public class FishMotorController
    {
        protected const float Smax = 0.075f;

        [SerializeField]
        protected List<float2> amplitudeParameter = new List<float2>(2)
        {
            new float2(0,1),
            new float2(0,1),
        };
        [SerializeField]
        protected List<float2> frequencyParameter = new List<float2>(2)
        {
            new float2(0,Smax),
            new float2(0,Smax),
        };
    }

    [Serializable]
    public class FishSwimmingMC : FishSimulator.Problem
    {
        [SerializeField] protected float speed = 1;

        public FishSwimmingMC() : base(FishActivationData.Type.Swimming)
        {
            FishActivationData.UpdateFFT(this.activations.Activations);
        }

        public override void ReloadData()
        {
            this.fish = this.fish ?? GeometryFunctions.Load();
        }
    }

    [Serializable]
    public class FishTurnMC : FishMotorController
    {
        //left is negative
        //right is positive
        [SerializeField] protected int angle = 0;
    }
}
