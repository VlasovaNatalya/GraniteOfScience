using System.Drawing;

namespace GraniteOfScience
{
    public class Level
    {
        public Terrain Terrain { get; private set; }

        // карта уровня только здесь
        private const string map = @"
P    TTT TTTT        TTTTT       TTTT
  TT TTTTTTT TTTTTTT     T  TTTT     
  TT          TTTTTTTTT     TTTT  TTT
 TT      T TTTTTTTTTTTTTTTTTTTT TTTT
TTT    TT    T    TTTTT TTTT      TTTT
 TTT TT         TTTTTTT   TTT TTTTTTTT
 TT     TTTTTTT TTTTTTTTT    TTTTTTTTT
 TTTTTTTTTTTTTT TTTTTTTTT TT  TTTTTTTT
  TTTTTTTTTTTTT TTTTTTTTTTT  TTTTTTTTT
T TTTTTTTTTTTTT TTTTTTTTTTTTTTTTTTTTTT
T TTTTTTTT                      TTTTTTT
TTTTTTTTTT TTTTTTTTT  TTT TTTTT   TTTTT
T           TTTTTTTTT TTT TTTTTTTTTTTTT
TTT  TTTTTTTTTTTTTTTTTTT TT TTTTT TTTTT
TTTT TTTTTTTTTTTTTTTTTTT        TTTTTT
TT T  T TTT TTTTTTTTTTTTTTTTTTTTTTTTTT
TTTT T TTT     TTT TTTT T TTTTTTTTTTTT
";

        public Level()
        {
            Terrain = new Terrain(map);
        }
    }
}