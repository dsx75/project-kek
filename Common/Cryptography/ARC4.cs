﻿namespace Common.Cryptography
{
    public class ARC4
    {
        private const int StateSize = 0x100;
        private readonly byte[] state;
        private byte x, y;

        public ARC4()
        {
            state = new byte[StateSize];
            x = y = 0;
        }

        public void SetKey(byte[] key)
        {
            x = y = 0;

            for (int i = 0; i < StateSize; i++)
                state[i] = (byte)i;

            var j = 0;
            for (int i = 0; i < StateSize; i++)
            {
                j = (byte)((j + key[i % key.Length] + state[i]) & 255);

                (state[i], state[j]) = (state[j], state[i]); // swap
            }
        }

        public void Process(byte[] buffer, int length)
        {
            for (int i = 0; i < length; i++)
            {
                x = (byte)((x + 1) % StateSize);
                y = (byte)((y + state[x]) % StateSize);

                (state[x], state[y]) = (state[y], state[x]); // swap

                buffer[i] = (byte)(state[(state[x] + state[y]) % StateSize] ^ buffer[i]);
            }
        }
    }
}
