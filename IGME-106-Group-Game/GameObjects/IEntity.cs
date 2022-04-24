using IGME106GroupGame.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.GameObjects
{
    // I made Entity an interface instead of a class since it only defines
    // fields and not unique functionalities for Entity classes.
    public interface IEntity
    {
        int Health { get; set; }
        Rectangle CollisionBox { get; }
        HealthBar HealthBar { get; }
    }
}
