using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VideoRentalData;
using VideoRental.Model;

namespace VideoRental.ViewModel
{
    class VideosViewModel : BaseViewModel
    {
        public ObservableCollection<Video> Videos { get; set; }
        object _SelectedVideo;
        DataClassesDataContext db = new DataClassesDataContext();
        public object SelectedVideo
        {
            get
            {
                return _SelectedVideo;
            }
            set
            {
                if (_SelectedVideo != value)
                {
                    _SelectedVideo = value;
                    RaisePropertyChanged("SelectedVideo");
                }
            }
        }

        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        string _TextProperty2;
        public string TextProperty2
        {
            get
            {
                return _TextProperty2;
            }
            set
            {
                if (_TextProperty2 != value)
                {
                    _TextProperty2 = value;
                    RaisePropertyChanged("TextProperty2");
                }
            }
        }


        string _TextProperty3;
        public string TextProperty3
        {
            get
            {
                return _TextProperty3;
            }
            set
            {
                if (_TextProperty3 != value)
                {
                    _TextProperty3 = value;
                    RaisePropertyChanged("TextProperty3");
                }
            }
        }


        string _TextProperty4;
        public string TextProperty4
        {
            get
            {
                return _TextProperty4;
            }
            set
            {
                if (_TextProperty4 != value)
                {
                    _TextProperty4 = value;
                    RaisePropertyChanged("TextProperty4");
                }
            }
        }


        string _TextProperty5;
        public string TextProperty5
        {
            get
            {
                return _TextProperty5;
            }
            set
            {
                if (_TextProperty5 != value)
                {
                    _TextProperty5 = value;
                    RaisePropertyChanged("TextProperty5");
                }
            }
        }


        public RelayCommand AddVideoCommand { get; set; }
        public RelayCommand DeleteVideoCommand { get; set; }


        public VideosViewModel()
        {
            var maxId = (from v in db.video
                         select v.id).Max();
            var minId = (from v in db.video
                         select v.id).Min();
            var q = from v in db.video
                    select v.id;
            List<int> availableIds = q.ToList();

            Videos = new ObservableCollection<Video>();
            for (int i = minId; i <= maxId; i++)
            {
                if (availableIds.Contains(i))
                {
                    Videos.Add((from v in db.video
                                 where v.id == i && v.title != null
                                 select new Video { Id = v.id, Title = v.title, Director = v.director, Year = v.year, Genre = v.genre, Medium = v.medium, Available = v.available }).FirstOrDefault());
                }
            }

            TextProperty1 = null;
            TextProperty2 = null;
            TextProperty3 = null;
            TextProperty4 = null;
            TextProperty5 = null;

            AddVideoCommand = new RelayCommand(AddVideo);
            DeleteVideoCommand = new RelayCommand(DeleteVideo);
        }

        void AddVideo(object parameter)
        {
            if (TextProperty1 == null || TextProperty2 == null || TextProperty3 == null || TextProperty4 == null || TextProperty5 == null)
            {
                return;
            }
            else
            {
                video v = new video { title = TextProperty1, director = TextProperty2, year = Convert.ToInt32(TextProperty3), genre = TextProperty4, medium = TextProperty5, available = true };
                db.video.InsertOnSubmit(v);
                db.SubmitChanges();
                Videos.Add(new Video { Title = TextProperty1, Director = TextProperty2, Year = Convert.ToInt32(TextProperty3), Genre = TextProperty4, Medium = TextProperty5, Available = true });
                RaisePropertyChanged("Videos");
                TextProperty1 = null;
                TextProperty2 = null;
                TextProperty3 = null;
                TextProperty4 = null;
                TextProperty5 = null;
            }
        }

        void DeleteVideo(object parameter)
        {
            if (SelectedVideo == null)
            {
                return;
            }
            else
            {
                var v1 = SelectedVideo as Video;
                var v2 = from v in db.video
                         where v.title == v1.Title
                         select v;
                var r1 = from r in db.rental join v in db.video
                         on r.videoId equals v.id
                         where v.title == v1.Title
                         select r;

                db.SubmitChanges();
                foreach (video v in v2)
                {
                    db.video.DeleteOnSubmit(v);
                    foreach (rental r in r1)
                        db.rental.DeleteOnSubmit(r);
                }
                db.SubmitChanges();
                Videos.Remove(v1);
                RaisePropertyChanged("Videos");
            }
        }
    }
}
