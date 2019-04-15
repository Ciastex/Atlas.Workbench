using System;

namespace Atlas.Workbench.Security
{
    public class DestructibleString : IDisposable
    {
        private char[] _data;
        private int _readIndex;
        private int _writeIndex;

        private bool _disposed;
        private bool _disposing;

        public int ActualLength
        {
            get
            {
                if (_disposed || _disposing)
                    throw new InvalidOperationException("DestructibleString instance already disposed.");

                return GetLength();
            }
        }

        public byte[] ActualBytes
        {
            get
            {
                if (_disposed || _disposing)
                    throw new InvalidOperationException("DestructibleString instance already disposed.");

                return AsBytes();
            }
        }

        public char Next
        {
            get
            {
                if (_disposed || _disposing)
                    throw new InvalidOperationException("DestructibleString instance already disposed.");

                return _data[_readIndex++ % GetLength()];
            }
        }

        public int MaxLength
        {
            get
            {
                if (_disposed || _disposing)
                    throw new InvalidOperationException("DestructibleString instance already disposed.");

                return _data.Length;
            }
        }

        public DestructibleString(int size)
        {
            _data = new char[size];

            _writeIndex = 0;
            _readIndex = 0;

            _disposed = false;
        }

        public void Dispose()
        {
            if (_disposed || _disposing)
                throw new InvalidOperationException("DestructibleString instance already disposed or is currently being disposed.");

            _disposing = true;

            for (var i = 0; i < _data.Length; i++)
                _data[i] = (char)0;

            _data = new char[0];
            _readIndex = 0;
            _writeIndex = 0;

            _disposed = true;

            _disposing = false;

            GC.Collect();
        }

        public void Append(char c)
        {
            if (_disposed || _disposing)
                throw new InvalidOperationException("DestructibleString instance already disposed.");

            _data[_writeIndex++ % _data.Length] = c;
        }

        public void SetAt(char c, int index)
        {
            if (_disposed || _disposing)
                throw new InvalidOperationException("DestructibleString instance already disposed.");

            _data[index] = c;
        }

        private byte[] AsBytes()
        {
            if (ActualLength == 0)
                return new byte[0];

            var data = new byte[GetLength()];
            _data.CopyTo(data, 0);

            return data;
        }

        private int GetLength()
        {
            var length = 0;
            for (var i = 0; i < _data.Length; i++)
            {
                if (_data[i] == 0) break;
                length++;
            }

            return length;
        }
    }
}