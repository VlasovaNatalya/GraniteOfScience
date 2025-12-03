using System.Drawing;

namespace GraniteOfScience
{
    public class Level
    {
        public Terrain Terrain { get; private set; }
        public Point TeacherStartPosition { get; private set; }

        // карта уровня только здесь
        private const string map = @"
PDTT TTT TTTT        TTTTT       TTTT
  T  TTTTTTT TTTTTTT     T  TTTT     
  D           TTTTTTTTT     TTTT  TTT
 TT      T TTTTTTTTTTTTTTTTTTTT DTTT
TTT    TT    T    TTTTT TTTT      TTTT
 TTT TD        DTTTTTT   TTT TTTTTTTT
 TT     TTTTTTT TTTTTTTTT    TTTTTTTTT
 TTTTTTTTDTTTTT DTTTTTTTT TD  TTTTTTTT
  DTTTTTTTTTTTT TTTTTTTTTTT  TTTTTTTTT
T TTTTTTTTTTTTT TTTTTTTTTTTTTTTTTTTTTT
T TTTTTTTT         DTTTTD         TTTTTTT
TTTTTTTTTT TTTTTTTTT  TTT TTTTT   TTTTT
T         R DTTTTTTTT TTT TTTTTTTTTTTTT
TTT  TTTTTTTTTTTTTTTTTTT TT TTTTT TTTTT
TTTT TTTTTTTTTTTTTTTTTTT   DTTT   TTTTTT
TT D  T TTT TTTTTTTTTTTTTTTTTTTTTTTTTTT
TTTT T TTT     TTT TTTT D TTTTTTTTTTTTT
";

        public Level()
        {
            Terrain = new Terrain(map);
        }
    }
}