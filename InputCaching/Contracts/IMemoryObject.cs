namespace InputCaching
{
    public interface IMemoryObject
    {
        //string UniquCombo();

        /// <summary>
        /// Should Generate a unique hash value for the input.
        /// </summary>
        /// <returns></returns>
        string Hash();
    }
}
