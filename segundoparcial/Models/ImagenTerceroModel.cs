using System.Buffers.Text;
using System;
using Entidad;


namespace segundoparcial.Models
{

    public class ImagenTerceroViewModel
    {

        public int ImagenTerceroID {get;set;}
        public string Imagen {get;set;}
        public ImagenTerceroViewModel()
        {
        }

        public ImagenTerceroViewModel(ImagenTercero imagenTercero)
        {
            ImagenTerceroID = imagenTercero.ImagenTerceroID;
            Imagen = "data:image/jpeg;base64," + ConvertirByteToImage(imagenTercero.Imagen);      
        }   
        public string ConvertirByteToImage(byte[] img)
        { 
            return Convert.ToBase64String(img);
        }

    }
        
}