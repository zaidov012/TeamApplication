using TeamApplication.Model;

namespace TeamApplication.ViewModel
{
    public class BaseViewModel
    {
        private readonly BaseModel _baseModel;

        public BaseViewModel(BaseModel baseModel)
        {
            _baseModel = baseModel;
        }
    }
}