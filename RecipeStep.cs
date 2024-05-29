namespace RecipeApp
{

    public class RecipeStep
    {
        public string Description { get; set; }

        public RecipeStep(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}

