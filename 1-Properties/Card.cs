namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card : IEquatable<Card>
    {
        public string Seed { get; set; }
        public string Name { get; }
        public int Ordinal { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            Name = name;
            Ordinal = ordinal;
            Seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple) : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(Name={Name}, Seed={Seed}, Ordinal={Ordinal})";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        // TODO generate Equals(object obj)
        public bool Equals(Card other)
        {
            return other != null &&
                   Seed == other.Seed &&
                   Name == other.Name &&
                   Ordinal == other.Ordinal;
        }

        // TODO generate GetHashCode()
        public override int GetHashCode()
        {
            return HashCode.Combine(Seed, Name, Ordinal);
        }


    }
}
