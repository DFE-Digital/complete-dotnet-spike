namespace Dfe.Complete.Utils
{
    public static class StringChunker
    {
        public static string[] Chunk(string value, int chunkSize)
        {
            if(string.IsNullOrEmpty(value))
            {
                return [""];
            }

            var tracker = 0;
            
            var output = new string[(value.Length / chunkSize) + (value.Length % chunkSize == 0 ? 0 : 1)];
            for(var i = 0; i < output.Length - 1; i++)
            {
                var chunk = value.Substring(tracker, chunkSize);
                output[i] = chunk;
                tracker += chunkSize;
            }

            output[output.Length -1] = value.Substring(tracker);
            
            return output;
        }
    }
}
