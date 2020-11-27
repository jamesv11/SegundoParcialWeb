using System.IO;
using System.Net.Mime;
using Entidad;
using System.Drawing;




namespace segundoparcial.Models
{
    
    public class ImagenTerceroViewModel
    {

        public int ImagenTerceroID {get;set;}
        
        

        public ImagenTerceroViewModel()
        {
        }

        public ImagenTerceroViewModel(ImagenTercero imagenTercero)
        {
            ImagenTerceroID = imagenTercero.ImagenTerceroID;

            
            
        }   

    }
        
}