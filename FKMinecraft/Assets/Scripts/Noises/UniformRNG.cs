﻿using System;
using Minecraft.Lua;

namespace Minecraft.Noises
{
    [XLua.GCOptimize]
    public struct UniformRNG : ILuaCallCSharp
    {
        // https://en.wikipedia.org/wiki/Linear_congruential_generator
        // MMIX by Donald Knuth
        public const ulong Multiplier = 6364136223846793005;
        public const ulong Increment = 1442695040888963407;

        private ulong m_State;
        private uint m_Count;

        public UniformRNG(ulong state)
        {
            m_Count = 101;

            if (state == 0)
            {
                DateTime time = DateTime.Now;
                ulong seed = (ulong)(time.Day << 25 | time.Hour << 20 | time.Minute << 14 | time.Second << 8 | time.Millisecond);

                for (int i = 0; i < 4; i++)
                {
                    seed = seed * Multiplier + Increment;
                }

                m_State = seed;
            }
            else
            {
                m_State = state;
            }
        }

        public int NextInt32()
        {
            return (int)Next();
        }

        public uint NextUInt32()
        {
            return Next();
        }

        public long NextInt64()
        {
            Next();
            return (long)m_State;
        }

        public ulong NextUInt64()
        {
            Next();
            return m_State;
        }

        public float NextSingle()
        {
            return Next() * 2.3283064365386962890625e-10f;
        }

        public double NextDouble()
        {
            var t = Next();
            return (((ulong)t << 32) | Next()) * 5.4210108624275221700372640043497e-20;
        }

        public int Uniform(int a, int b)
        {
            return a == b ? a : (int)(Next() % (b - a) + a);
        }

        public uint Uniform(uint a, uint b)
        {
            return a == b ? a : Next() % (b - a) + a;
        }

        public long Uniform(long a, long b)
        {
            return a == b ? a : Next() % (b - a) + a;
        }

        public ulong Uniform(ulong a, ulong b)
        {
            return a == b ? a : Next() % (b - a) + a;
        }

        public float Uniform(float a, float b)
        {
            return NextSingle() * (b - a) + a;
        }

        public double Uniform(double a, double b)
        {
            return NextDouble() * (b - a) + a;
        }

        private uint Next()
        {
            --m_Count;

            if (m_Count == 0)
            {
                for (int i = 0; i < 4; ++i)
                {
                    m_State = m_State * Multiplier + Increment;
                }

                m_Count = 101;
            }

            m_State ^= m_State >> 21;
            m_State ^= (m_State << 13) | 0x73a4b9de9d2c5680;
            m_State ^= (m_State << 29) & 0x5b3e6da7efc67a5b;
            m_State ^= m_State >> 33;
            return (uint)m_State;
        }
    }
}
