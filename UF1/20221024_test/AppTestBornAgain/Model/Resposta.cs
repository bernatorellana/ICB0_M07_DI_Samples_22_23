using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestBornAgain.Model
{
    public class Resposta
    {
        private string text;
        private bool correcta;
        private bool seleccionada;

        public Resposta(string text, bool correcta)
        {
            Text = text;
            Correcta = correcta;
            seleccionada = false;
        }

        public string Text { get => text; set => text = value; }
        public bool Correcta { get => correcta; set => correcta = value; }
        public bool Seleccionada { get => seleccionada; set => seleccionada = value; }
    }
}
