namespace Crypto_Lab03
{
    class Clent
    {
        string message;

        public Clent(string message)
        {
            this.message = message;
        }

        public string Change(string symbol, int key) 
        {
            int position = message.IndexOf(symbol);
            if (position == -1)
                return ""; 

            position = (position + key) % message.Length;
            
            if (position < 0)
                position += message.Length;

            return message.Substring(position, 1);
        }
    }
}
