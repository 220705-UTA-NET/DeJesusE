
namespace Battleship
{
    // A pseudo-enum class representing pieces in the game Battleship
    class Pieces
    {
        // The ID of the Piece object. Used to differentiate it from the other objects. Setter is set to private to prevent outside classes from
        // modifying the object.
        public int Id { get; private set; }
        // The name of the piece that this object is representing
        public string Name { get; private set; }
        // The number of slots that this piece occupies
        public int Size { get; private set; }
        // Character used to represent this piece on the player's board
        public char Symbol { get; private set; }

        // Defines a set number of pieces to shared amongst the rest of the classes in the application.
        public static Pieces Battleship = new(1, 'B', nameof(Battleship), 4);
        public static Pieces Carrier = new(2, 'A', nameof(Carrier), 5);
        public static Pieces Cruiser = new(3, 'C', nameof(Cruiser), 3);
        public static Pieces Destroyer = new(4, 'D', nameof(Destroyer), 2);
        public static Pieces Submarine = new(5, 'S', nameof(Submarine), 3);

        // Set to private to prevent other objects from generating more pieces.
        private Pieces(int id, char symbol, string name, int size)
        {
            Id = id;
            Symbol = symbol;
            Name = name;
            Size = size;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}