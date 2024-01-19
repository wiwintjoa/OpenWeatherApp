using System.Collections.Generic;

namespace OpenWeatherApp.ServiceContract.Response
{
    public class GenericGetDtoCollectionResponse<TDto> : BasicResponse
    {
        #region Fields

        private List<TDto> _dtoList;

        #endregion

        #region Constructor

        public GenericGetDtoCollectionResponse()
        {
        }

        public GenericGetDtoCollectionResponse(int capacity)
        {
            _dtoList = new List<TDto>(capacity);
        }

        #endregion

        #region Properties

        public ICollection<TDto> DtoCollection
        {
            get { return _dtoList ?? (_dtoList = new List<TDto>()); }
        }

        #endregion
    }
}
