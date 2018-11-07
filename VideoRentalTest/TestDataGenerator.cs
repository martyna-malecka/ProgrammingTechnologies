using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRentalTest{
	
    class TestDataGenerator{
		return new List <Client>(){
			new Client("Szymon", "Rogalski"),
			new Client("Martyna", "Małecka")
		};
		
	private class Client : Client{
		
		public Client(String name, String surname, String id, double debt){
            name = _name;
            surname = _surname;
            id = Guid.NewGuid().ToString();
            debt = 0;
			for int i=0; i<5; i++){
				_rentedVideo.Add(new IVideo(){
					year = _year;
					title = _title;
					director = _director;
					genre = _genre;
					id = Guid.NewGuid().ToString();
					available = true;
				}
		};
		
	}
	
	# region Client
	public String name{
		get;
		private set;
	}
	public String surname{
		get;
		private set;
	}
	# endregion
	
	private List <IVideo> _rentedVideo = new List <IVideo>();
	}
	
	private class IVideo : IVideo{
		
	# region IVideo
	public String title{
		get;
		set;
	}
	public String director{
		get;
		set;
	}
	public String genre{
		get;
		set;
	}
	public String id{
		get;
		set;
	}
	public bool available{
		get;
		set;
	}
	public int year{
		get;
		set;
	}
	# endregion
	}
}
}
