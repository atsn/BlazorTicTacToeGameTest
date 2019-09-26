using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TicTacToeBlazerFun.HelperClasses
{
    public class Player
    {
        private char _symbol;

        [Required]
        [StringLength(30, ErrorMessage = "I dont belive you have this long of a name")]
        public string Name { get; set; }

        public short? AiLevel { get; set; }

        [Required]
        public char Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public Player(string name, char symbol, short? aiLevel = null)
        {
            Name = name;
            Symbol = symbol;
            AiLevel = aiLevel;
        }
    }

    public class ChosePlayerModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "I dont belive you have this long of a name")]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        public string Symbol { get; set; }

        public short AiLevel { get; set; }

        public ChosePlayerModel()
        {
            Name = Statics.GetRandomName();
            AiLevel = -1;
        }

        public Player GetPlayer()
        {
            if (Symbol == "|" || Symbol.Length > 1 || Symbol.Length < 0)
            {
                throw new ArgumentException("The symbol is not valid");
            }

            return AiLevel < 0 ? new Player(Name, Symbol.FirstOrDefault(), null) : new Player(Name, Symbol.FirstOrDefault(), AiLevel);
        }
    }
}
