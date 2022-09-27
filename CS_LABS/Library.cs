using CS_LABS.SUP_CLASSES;

namespace CS_LABS;

public struct Library
{
    public Library()
    {
        
    }
    private readonly Math _math = new Math();
    private readonly Labs _labs = new Labs();
    private readonly Arrays _arrays = new Arrays();
}