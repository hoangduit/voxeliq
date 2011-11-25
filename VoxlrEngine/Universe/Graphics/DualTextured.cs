﻿/*
 * Copyright (C) 2011 voxlr project 
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace VolumetricStudios.VoxlrEngine.Universe.Graphics
{
    [Serializable]
    public struct DualTextured : IVertexType
    {
        private Vector3 _position;
        private HalfVector2 _blockTextureCoordinate;
        private HalfVector2 _crackTextureCoordinate;
        private float _ambientOcclusionWeight;

        public DualTextured(Vector3 position, HalfVector2 blockTextureCoordinate, HalfVector2 crackTextureCoordinate, float ambientOcclusionWeight)
        {
            _position = position;
            _blockTextureCoordinate = blockTextureCoordinate;
            _crackTextureCoordinate = crackTextureCoordinate;
            _ambientOcclusionWeight = ambientOcclusionWeight;
        }
        
        VertexDeclaration IVertexType.VertexDeclaration { get { return VertexDeclaration; } }

        private static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new[]
        {         
            new VertexElement(0,VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
            new VertexElement(sizeof(float)*3,VertexElementFormat.HalfVector2,  VertexElementUsage.TextureCoordinate, 0),
            new VertexElement(sizeof(float)*4,VertexElementFormat.HalfVector2,  VertexElementUsage.TextureCoordinate, 1),
            new VertexElement(sizeof(float)*5,VertexElementFormat.Single,  VertexElementUsage.Color, 0) 
        });

        public Vector3 Position { get { return _position; } set { _position = value; } }
        public HalfVector2 BlockTextureCoordinate { get { return _blockTextureCoordinate; } set { _blockTextureCoordinate = value; } }
        public HalfVector2 CrackTextureCoordiante { get { return _crackTextureCoordinate; } set { _crackTextureCoordinate = value; } }
        public float AmbientOcclusionWeight { get { return _ambientOcclusionWeight; } set { _ambientOcclusionWeight = value; } }
        public static int SizeInBytes { get { return sizeof(float) * 6; } }
    }
}
