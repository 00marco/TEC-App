using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.ViewModels
{
    public class Sender
    {
	    public readonly Adapter _adapter;

	    public Sender(Adapter adapter)
	    {
		    _adapter = adapter;
		    _adapter.SelectedPerson = "ASd";
	    }
    }

    public class Receiver
    {
	    public readonly Adapter _adapter;
	    public Receiver(Adapter adapter)
	    {
		    _adapter = adapter;
			_adapter.ShowPerson();
	    }
    }

    public class Adapter
    {
	    public string SelectedPerson { get; set; }

	    public void ShowPerson()
	    {
			
	    }
    }

    public class Test
    {
	    private Adapter adapter = new Adapter();

	    public Test()
	    {
		    var adapter = new Adapter();
			var sender = new Sender(adapter);
			var receiver = new Receiver(adapter);
			adapter.SelectedPerson = "asd";
			
	    }
    }
}
