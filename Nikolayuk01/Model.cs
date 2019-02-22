
using System;
using System.ComponentModel;

using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;


namespace Nikolayuk01
{
    class Model : INotifyPropertyChanged
    {
        public int AgeGetting(DateTime _date)
        {
            DateTime? selectedDate = _date;
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime today = DateTime.Today;
            TimeSpan span = today -_date;
            int age = (zeroTime + span).Year - 1;

            return age;

        }

        /*Aries (21 March-20 April)
        Taurus (21 April-21 May)
        Gemini (22 May-21 June)
        Cancer (22 June-22 July)
        Leo (23 July-22 August)
        Virgo (23 August-21 September)
        Libra (22 September-22 October)
        Scorpio (23 October-21 November)
        Sagittarius (22 November-21 December)
        Capricorn (22 December-20 January)
        Aquarius (21 January-19 February)
        Pisces (20 February-20 March)*/

        public string GetWesternHoroscope(DateTime _date)
        {
            string b = "";
            switch (_date.Month)
            {
                case 1:
                    return _date.Day <= 19 ? "Capricorn" : "Aquarius";

                case 2:
                    return _date.Day <= 18 ? "Aquarius" : "Pisces";

                case 3:
                    return _date.Day <= 20 ? "Pisces" : "Aries";

                case 4:
                    return _date.Day <= 19 ? "Aries" : "Taurus";

                case 5:
                    return _date.Day <= 20 ? "Taurus" : "Gemini";

                case 6:
                    return _date.Day <= 20 ? "Gemini" : "Cancer";

                case 7:
                    return _date.Day <= 22 ? "Cancer" : "Leo";

                case 8:
                    return _date.Day <= 22 ? "Leo" : "Virgo";

                case 9:
                    return _date.Day <= 22 ? "Virgo" : "Libra";

                case 10:
                    return _date.Day <= 22 ? "Libra" : "Scorpio";

                case 11:
                    return _date.Day <= 21 ? "Scorpio" : "Sagittarius";

                case 12:
                    return _date.Day <= 21 ? "Sagittarius" : "Capricorn";

            }
            
            return b;
        }


        public DateTime _date = DateTime.Today;
        public int age;
        public string zodiac1;
        public string zodiac2;
        private RelayCommand<object> fieldAge;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Age => $"The age is: {age}";

        public string Zodiac1 => $"Western zodiac is: {zodiac1}";

        public string Zodiac2 => $"Chinese zodiac is {zodiac2}";

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                if (AgeGetting(_date) > 135)
                {
                    MessageBox.Show("Invalid data - not you");
                }

                if (_date.CompareTo(DateTime.Today) > 0)
                {
                    MessageBox.Show("Invalid data - not you");
                }

                if (_date.CompareTo(DateTime.Today) == 0)
                {
                    MessageBox.Show("you deserve a beer today, it's your bd");
                }
                zodiac1 = GetWesternHoroscope(_date);
                zodiac2 = GetChinaHoroscope(_date);

               
                OnPropertyChanged(nameof(Zodiac1));
                OnPropertyChanged(nameof(Zodiac2));
                
            }
        }

        public string GetChinaHoroscope(DateTime _date)
        {
            string a = "";
            if (((_date.Year - 4) % 12) == 0)
                a = "Krysa";
            if (((_date.Year - 4) % 12) == 1)
                a = "Byk";
            if (((_date.Year - 4) % 12) == 2)
                a = "Tygr";
            if (((_date.Year - 4) % 12) == 3)
                a = "Krolik";
            if (((_date.Year - 4) % 12) == 4)
                a = "Dragon";
            if (((_date.Year - 4) % 12) == 5)
                a = "Zmeya";
            if (((_date.Year - 4) % 12) == 6)
                a = "Loshad";
            if (((_date.Year - 4) % 12) == 7)
                a = "Kosel";
            if (((_date.Year - 4) % 12) == 8)
                a = "Obezyna";
            if (((_date.Year - 4) % 12) == 9)
                a = "Petuh";
            if (((_date.Year - 4) % 12) == 10)
                a = "Sobaka";
            if (((_date.Year - 4) % 12) == 11)
                a = "Svinya";
            return a;
            /*  switch ((_date.Year - 4) % 12)
              {
                  case 0:
                      return "Rat";   
                  case 1:
                      return "Ox";
                  case 2:
                      return "Tiger";
                  case 3:
                      return "Rabbit";
                  case 4:
                      return "Dragon";
                  case 5:
                      return "Snake";
                  case 6:
                      return "Horse";
                  case 7:
                      return "Goat";
                  case 8:
                      return "Monkey";
                  case 9:
                      return "Rooster";
                  case 10:
                      return "Dog";
                  case 11:
                      return "Pig";
  
              }
  
              return "";
          }*/
        }

        public RelayCommand<object> ShowGoroscope
        {
            get
            {
                return fieldAge ?? (fieldAge = new RelayCommand<object>(
                           AsCommand, o => CanExecuteCommand()));
            }
        }
        private async void AsCommand(object obj)
        {
            await Task.Run(() =>
                {
                    age = AgeGetting(_date);
                    OnPropertyChanged(nameof(Age));


                }
            );
        }

        private static Task Run(Func<object> p)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_date.ToString());
        } 
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
