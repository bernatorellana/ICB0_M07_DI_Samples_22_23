using System;
using System.Collections.Generic;

namespace AppTestBornAgain.Model
{
    public class Pregunta
    {
        private int id;
        private String enunciat;
        private List<Resposta> respostes;
        private bool esMultiresposta;
        //------------------------------



        private static List<Pregunta> preguntesTest;
        public static List<Pregunta> getPreguntesTest()
        {
            if (preguntesTest == null)
            {
                preguntesTest = new List<Pregunta>();


                preguntesTest.Add(new Pregunta(
                    1,
                    "Com et dius?",
                    new List<string>(new string[] { "Paco", "Maria", "Cristina", "Mari Pili", "Mortadelo", "Morphius" }),
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


        public Pregunta(int id, string enunciat, 
            List<string> respostes,
            int respostaCorrecta)
        {
            Id = id;
            Enunciat = enunciat;
            Respostes = new List<Resposta>();
            int idx = 0;
            foreach (String t in respostes)
            {
                Resposta r = new Resposta(t, idx == respostaCorrecta);
                Respostes.Add(r);
                idx++;
            }

            EsMultiresposta = false;
        }

        public int Id { get => id; set => id = value; }
        public string Enunciat { get => enunciat; set => enunciat = value; }
        public List<Resposta> Respostes { get => respostes; set => respostes = value; }
        public bool EsMultiresposta { get => esMultiresposta; set => esMultiresposta = value; }
    }
}