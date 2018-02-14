using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Interfaces
{
    public interface IDestroyable
    {
        int HitPoint { get; set; }

        void Hit();

        void Hit(int damage);

        void Destroy();
    }
}
