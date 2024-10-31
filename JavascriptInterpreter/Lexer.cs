using System.Collections.Immutable;
using System.Text;

namespace JavascriptInterpreter
{
    public class Lexer
    {
        public static IImmutableList<Token> Lex(string input)
        {
            var result = new List<Token>();

            for (int i = 0; i < input.Length; i++)
            {
                Token currentToken = DefaultTokenValidation(input[i]);

                if (currentToken.MyTipe is not Type.NotMapped)
                {
                    result.Add(currentToken);
                    continue;
                }

                var sb = new StringBuilder(input[i]);

                for (int j = i; j < input.Length; j++)
                {
                    //Guid Validation
                    if (char.IsLetter(input[j]) || char.IsDigit(input[j]) || Equals(input[j], '-') || Equals(input[j], '_') || Equals(input[j], '.'))
                    {
                        sb = sb.Append(input[j]);
                    }
                    else
                    {
                        var internalResult = sb.ToString();

                        if (internalResult.Length == 36)
                        {
                            result.Add(new Token(Type.Guid, internalResult));
                        }
                        else if (internalResult.Length >= 1)
                        {
                            result.Add(new Token(Type.NotMapped, internalResult));
                        }

                        result.Add(DefaultTokenValidation(input[j]));
                        break;
                    }

                    i++;
                }
            }

            return result.ToImmutableList();
        }

        private static Token DefaultTokenValidation(char input)
        {
            return input switch
            {
                '(' => new Token(Type.LeftParentesis, "("),
                ')' => new Token(Type.RightParentesis, ")"),
                ' ' => new Token(Type.WhiteSpace, " "),
                '\r' => new Token(Type.LineScape, "\r"),
                '\n' => new Token(Type.LineScape, "\n"),
                '+' => new Token(Type.Sign, "+"),
                '=' => new Token(Type.Sign, "="),
                _ => new Token(Type.NotMapped, input.ToString())
            };
        }
    }
}
