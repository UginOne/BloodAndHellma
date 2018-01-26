using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Interfaces
{
    public interface IDestroyable
    {
        void Hit();

        void Destroy();
    }
}
