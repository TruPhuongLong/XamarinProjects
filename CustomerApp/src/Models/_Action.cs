using System;
namespace CustomerApp.src.Models
{
	public interface _Action
    {
		_Type _Type { get;}
		Object Payload { get;}
    }

	public enum _Type
	{
		Login,
        Signup,
	}
}
