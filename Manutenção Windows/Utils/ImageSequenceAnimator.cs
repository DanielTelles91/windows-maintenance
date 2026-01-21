using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Manutenção_Windows.Utils
{
    internal class ImageSequenceAnimator
    {
        private readonly PictureBox _pictureBox;
        private readonly Timer _timer;
        private readonly Image[] _frames;
        private int _frameAtual = 0;

        public ImageSequenceAnimator(PictureBox pictureBox, string pastaFrames, int intervalo = 250)
        {
            _pictureBox = pictureBox;

            _frames = Directory.GetFiles(pastaFrames, "*.png")
                               .OrderBy(f => f)
                               .Select(Image.FromFile)
                               .ToArray();

            if (_frames.Length == 0)
                throw new Exception("Nenhuma imagem encontrada para animação.");

            _timer = new Timer();
            _timer.Interval = intervalo;
            _timer.Tick += (s, e) => AvancarFrame();
        }

        //  NOVO CONSTRUTOR (RESOURCES EMBUTIDOS)
        public ImageSequenceAnimator(PictureBox pictureBox, Image[] frames, int intervalo = 250)
        {
            _pictureBox = pictureBox;
            _frames = frames;

            if (_frames == null || _frames.Length == 0)
                throw new Exception("Nenhuma imagem encontrada para animação.");

            _timer = new Timer();
            _timer.Interval = intervalo;
            _timer.Tick += (s, e) => AvancarFrame();
        }


        private void AvancarFrame()
        {
            _pictureBox.Image = _frames[_frameAtual];
            _frameAtual = (_frameAtual + 1) % _frames.Length;
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();
    }
}
