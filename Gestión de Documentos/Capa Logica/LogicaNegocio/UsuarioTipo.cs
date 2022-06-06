namespace Capa_Logica.LogicaNegocio
{
    public class UsuarioTipo
    {

        protected int usuario_id;
        protected string usuario_tipo;

        public UsuarioTipo(int usuario_id, string usuario_tipo)
        {
            this.usuario_id = usuario_id;
            this.usuario_tipo = usuario_tipo;
        }

        public int Usuario_id { get => usuario_id; set => usuario_id = value; }
        public string Usuario_tipo { get => usuario_tipo; set => usuario_tipo = value; }
    }
}
