﻿/*
 * Copyright (C) 2011-2012 Volumetric Studios
 *
 */

using VolumetricStudios.VoxeliqGame.Chunks.Generators.Biomes;
using VolumetricStudios.VoxeliqGame.Utils.Algorithms;

namespace VolumetricStudios.VoxeliqGame.Chunks.Generators.Terrain
{
    public class MountainousTerrain : BasicTerrain
    {
        public MountainousTerrain(BiomeGenerator biomeGenerator)
            : base(biomeGenerator)
        { }

        protected override float GetRockHeight(int blockX, int blockZ)
        {
            int minimumGroundheight = Chunk.HeightInBlocks/4;
            int minimumGroundDepth = (int) (Chunk.HeightInBlocks*0.7f);

            float octave1 = PerlinSimplexNoise.noise(blockX*0.0001f, blockZ*0.0001f)*0.5f;
            float octave2 = PerlinSimplexNoise.noise(blockX*0.0005f, blockZ*0.0005f)*0.25f;
            float octave3 = PerlinSimplexNoise.noise(blockX*0.005f, blockZ*0.005f)*0.12f;
            float octave4 = PerlinSimplexNoise.noise(blockX*0.01f, blockZ*0.01f)*0.12f;
            float octave5 = PerlinSimplexNoise.noise(blockX*0.03f, blockZ*0.03f)*octave4;

            float lowerGroundHeight = octave1 + octave2 + octave3 + octave4 + octave5;

            lowerGroundHeight = lowerGroundHeight*minimumGroundDepth + minimumGroundheight;

            return lowerGroundHeight;
        }
    }
}