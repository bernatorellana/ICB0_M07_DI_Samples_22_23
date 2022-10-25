namespace AppTest.Model
{
    public class Pregunta
    {
        private int id;
        private String enunciat;
        private List<String> respostes;
        private List<int> repostesCorrectes;
        private bool esMultiresposta;
        //------------------------------
        private List<int> respostesSeleccionades;



        private static List<Pregunta> preguntesTest;
        public static List<Pregunta> getPreguntesTest()
        {
            if (preguntesTest == null)
            {
                preguntesTest = new List<Pregunta>();


                preguntesTest.Add(new Pregunta(
                    1,
                    "Com et dius?",
                    new List<string>(new string[] { "Paco", "Maria", "Cristina" }),
                    0
                    ));
                preguntesTest.Add(new Pregunta(
                    2,
                    "Qui és el teu pare?",
                    new List<string>(new string[] { "Paco", "Darth Vader", "Cristina" }),
                    1
                    ));

            }
            return preguntesTest;
        }


        public Pregunta(int id, string enunciat, List<string> respostes,
            int respostaCorrecta)
        {
            Id = id;
            Enunciat = enunciat;
            Respostes = respostes;
            RepostesCorrectes = new List<int>();
            RepostesCorrectes.Add(respostaCorrecta);
            EsMultiresposta = false;
        }

        public int Id { get => id; set => id = value; }
        public string Enunciat { get => enunciat; set => enunciat = value; }
        public List<string> Respostes { get => respostes; set => respostes = value; }
        public List<int> RepostesCorrectes { get => repostesCorrectes; set => repostesCorrectes = value; }
        public bool EsMultiresposta { get => esMultiresposta; set => esMultiresposta = value; }
    }
}