using ChroniqueOublieAPI.Models.Voie;

namespace ChroniqueOublieAPI.Service.Interface
{
    public interface IVoieServiceInterface
    {
        VoieDTO Create(VoieDTO voieDto);

        VoieDTO ReadByName(VoieDTO voieDto);

        VoieDTO ReadById(VoieDTO voieDto);

        VoieDTO Update(VoieDTO voieDto);

        VoieDTO Delete(VoieDTO voieDto);
    }
}