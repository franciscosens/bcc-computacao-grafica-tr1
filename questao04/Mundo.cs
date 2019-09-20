
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Input;
using CG_Biblioteca;
using Color = OpenTK.Color;
using FormasBiblioteca;

namespace questao04
{
  class Mundo : GameWindow
  {
    public static Mundo instance = null;

    public Mundo(int width, int height) : base(width, height) { }

    public static Mundo getInstance()
    {
      if (instance == null)
        instance = new Mundo(600,600);
      return instance;
    }

    private Camera camera = new Camera();
    protected List<Objeto> objetosLista = new List<Objeto>();
    private bool moverPto = false;
    //FIXME: estes objetos não devem ser atributos do Mundo

    private List<PrimitiveType> tiposPrimitivas = new List<PrimitiveType> {PrimitiveType.Points, PrimitiveType.Lines,
            PrimitiveType.LineLoop, PrimitiveType.LineStrip, PrimitiveType.Triangles, PrimitiveType.TriangleStrip, PrimitiveType.TriangleFan,
            PrimitiveType.Quads, PrimitiveType.QuadStrip, PrimitiveType.Polygon};

    private int primitivaAtual = 0;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      var segmentoRetaA = new SegReta("A", new Ponto4D(0, 0, 0), new Ponto4D(200, 0, 0), Color.Red, 5);
      var segmentoRetaB = new SegReta("B", new Ponto4D(0, 0, 0), new Ponto4D(0, 200, 0), Color.Green, 5);

      var pontos = new List<Ponto4D>();
      pontos.Add(new Ponto4D(-200,-200,0));
      pontos.Add(new Ponto4D(-200,200,0));
      pontos.Add(new Ponto4D(200,200,0));
      pontos.Add(new Ponto4D(200,-200,0));
      

      // var pontosExtremos = new PontosExtremos( pontos);

      objetosLista.Add(segmentoRetaA);
      objetosLista.Add(segmentoRetaB);
      GL.ClearColor(Color.Gray);
    }
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);

      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(-300, 300, -300, 300, -1, 1);
    }
    protected override void OnRenderFrame(FrameEventArgs e) {
      base.OnRenderFrame(e);

      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadIdentity();

      for (var i = 0; i < objetosLista.Count; i++) {
        objetosLista[i].Desenhar();
      }

      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e) {
      if (e.Key == Key.Escape){
        Exit();
      }

      if (e.Key == Key.Space) {
        if (primitivaAtual == 9) {
          primitivaAtual = 0;
        } else {
          primitivaAtual++;
        }

        TextureFilterFuncSgis = tiposPrimitivas[primitivaAtual];
      }
    }

  }

}
