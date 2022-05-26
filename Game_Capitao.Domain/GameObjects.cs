using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Capitao.Domain
{
    public class GameObjects : List<EntityBase>
    {
        public new void Add(EntityBase entity)
        {
            base.Add(entity);
        }
    }
}
