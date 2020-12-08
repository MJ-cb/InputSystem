﻿using System.Runtime.CompilerServices;

namespace UnityEngine.InputSystem.DmytroRnD
{
    // This should be autogenerated
    internal struct MouseDemux
    {
        public enum Channels
        {
            PositionX,
            PositionY,
            DeltaX,
            DeltaY,
            ScrollX,
            ScrollY,
            ButtonLeft,
            ButtonRight,
            ButtonMiddle,
            ButtonForward,
            ButtonBack,
            Count
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Demux(ref ComputationalGraph graph, int deviceId, long timestamp, ulong* changed,
            void* rawState)
        {
            var state = (NativeMouseState*) rawState;

            //for (var i = 0; i < device.ChangedBits.Length; ++i)
            //    Debug.Log($"changed[{i}] = 0b{Convert.ToString((long)device.ChangedBits[i], 2).PadLeft(64, '0')}");

            if (changed[0] != 0)
            {
                if ((changed[0] & 0x00000000ffffffffUL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.PositionX, timestamp, state->Position.x);

                if ((changed[0] & 0xffffffff00000000UL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.PositionY, timestamp, state->Position.y);
            }

            if (changed[1] != 0)
            {
                if ((changed[1] & 0x00000000ffffffffUL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.DeltaX, timestamp, state->Delta.x);

                if ((changed[1] & 0xffffffff00000000UL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.DeltaY, timestamp, state->Delta.y);
            }

            if (changed[2] != 0)
            {
                if ((changed[2] & 0x00000000ffffffffUL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.ScrollX, timestamp, state->Scroll.x);

                if ((changed[2] & 0xffffffff00000000UL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.ScrollY, timestamp, state->Scroll.y);
            }

            if (changed[3] != 0)
            {
                if ((changed[3] & 0b0000000000000000000000000000000000000000000000000000000000000001UL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.ButtonLeft, timestamp,
                        ((state->Buttons & 0b0000000000000001) != 0) ? 1.0f : 0.0f);

                if ((changed[3] & 0b0000000000000000000000000000000000000000000000000000000000000010UL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.ButtonRight, timestamp,
                        ((state->Buttons & 0b0000000000000010) != 0) ? 1.0f : 0.0f);

                if ((changed[3] & 0b0000000000000000000000000000000000000000000000000000000000000100UL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.ButtonMiddle, timestamp,
                        ((state->Buttons & 0b0000000000000100) != 0) ? 1.0f : 0.0f);

                if ((changed[3] & 0b0000000000000000000000000000000000000000000000000000000000001000UL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.ButtonForward, timestamp,
                        ((state->Buttons & 0b0000000000001000) != 0) ? 1.0f : 0.0f);

                if ((changed[3] & 0b0000000000000000000000000000000000000000000000000000000000010000UL) != 0)
                    graph.RecordDeviceEvent(deviceId, (int) Channels.ButtonBack, timestamp,
                        ((state->Buttons & 0b0000000000010000) != 0) ? 1.0f : 0.0f);
            }
        }
    }
}