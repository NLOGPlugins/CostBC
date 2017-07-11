using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostBC
{
    public class OnEvent : CostBC
    {
        protected override void OnEnable()
        {
            Console.WriteLine("[CostBC] 플럭그인이 활성화 되었습니다!");
        }
    }
}
