using MySqlConnector;

namespace FindWordsAPI
{
    public class SearchInDB
    {
        public static string Search(string[] words)
        {
            var connection = new MySqlConnection("Server=Localhost;User ID=root;Password=\"\";Database=words");

            if (connection != null)
            {

                string answer = "";
                for (int i = 0; i < words.Length; i++)
                {


                    string s = $"select word from words where word = \"{words[i]}\"";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(s, connection);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        if (i == words.Length - 1)
                        {
                            answer += words[i];
                        }
                        else
                        {
                            answer += words[i] + " ";
                        }

                    }
                    connection.Close();
                }

                return answer;

            }

            else
            {
                return "No database Connection";
            }

        }

    }
}
