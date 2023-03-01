#region [ Using ]
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIMWebAPI.DataRepository;
#endregion

namespace CIMWebAPI.Data.Entities
{
   public class OutQueuePhone
   {
        public static string FormatPhoneNumber(string prvphone) {
            var nwphone = "";
            if (prvphone != null)
            {
               if (prvphone == "")
                {
                    nwphone = "0";
                } else
                {
                    nwphone = "";
                    foreach (var c in prvphone)
                    {
                        if ("0123456789".Contains(c))
                        {
                            nwphone += c;
                        }
                    }
                    if ((nwphone=string.Join("",nwphone.Split(" ")). Trim()).Length>=9)
                    {
                        while(nwphone.StartsWith("0") && nwphone.Length >=9)
                        {
                            nwphone = nwphone.Substring(1);
                        }
                        if (nwphone.Length >= 9)
                        {
                            if (nwphone.StartsWith("27"))
                            {
                                nwphone = nwphone.Substring(2);
                            }
                            if (!nwphone.StartsWith("0"))
                            {
                                nwphone = "0" + nwphone;
                            }
                        } else
                        {
                            return null;
                        }
                    } else
                    {
                        return null;
                    }
                }
            }
            return nwphone;
        }

        public int ServiceID { get; set; }
        public int ServiceIDOld { get; set; }
        public string Name { get; set; }

        string phone;
        public string Phone
        {
            get => this.phone; set
            {
                if (value != "")
                {
                    this.phone = FormatPhoneNumber(value);
                }
            }
        }
        public int SourceID { get; set; }
        public Nullable<int> Status { get; set; }
        public int LoadID { get; set; }
        public int LoadIDOld { get; set; }
        public int Priority { get; set; }

        string phone1;
        public string Phone1
        {
            get => this.phone1; set
            {
                if (value != "")
                {
                    this.phone1 = FormatPhoneNumber(value);
                }
            }
        }

        string phone2;
        public string Phone2
        {
            get => this.phone2; set
            {
                if (value != "")
                {
                    this.phone2 = FormatPhoneNumber(value);
                }
            }
        }

        string phone3;
        public string Phone3
        {
            get => this.phone3; set
            {
                if (value != "")
                {
                    this.phone3 = FormatPhoneNumber(value);
                }
            }
        }
        string phone4;
        public string Phone4
        {
            get => this.phone4; set
            {
                if (value != "")
                {
                    this.phone4 = FormatPhoneNumber(value);
                }
            }
        }
        string phone5;
        public string Phone5
        {
            get => this.phone5; set
            {
                if (value != "")
                {
                    this.phone5 = FormatPhoneNumber(value);
                }
            }
        }
        string phone6;
        public string Phone6
        {
            get => this.phone6; set
            {
                if (value != "")
                {
                    this.phone6 = FormatPhoneNumber(value);
                }
            }
        }
        string phone7;
        public string Phone7
        {
            get => this.phone7; set
            {
                if (value != "")
                {
                    this.phone7 = FormatPhoneNumber(value);
                }
            }
        }
        string phone8;
        public string Phone8
        {
            get => this.phone8; set
            {
                if (value != "")
                {
                    this.phone8 = FormatPhoneNumber(value);
                }
            }
        }
        string phone9;
        public string Phone9
        {
            get => this.phone9; set
            {
                if (value != "")
                {
                    this.phone9 = FormatPhoneNumber(value);
                }
            }
        }
        string phone10;
        public string Phone10
        {
            get => this.phone10; set
            {
                if (value != "")
                {
                    this.phone10 = FormatPhoneNumber(value);
                }
            }
        }
        public Nullable<int> PhoneDesc1 { get; set; }
        public Nullable<int> PhoneDesc2 { get; set; }
        public Nullable<int> PhoneDesc3 { get; set; }
        public Nullable<int> PhoneDesc4 { get; set; }
        public Nullable<int> PhoneDesc5 { get; set; }
        public Nullable<int> PhoneDesc6 { get; set; }
        public Nullable<int> PhoneDesc7 { get; set; }
        public Nullable<int> PhoneDesc8 { get; set; }
        public Nullable<int> PhoneDesc9 { get; set; }
        public Nullable<int> PhoneDesc10 { get; set; }
        public Nullable<int> PhoneStatus1 { get; set; }
        public Nullable<int> PhoneStatus2 { get; set; }
        public Nullable<int> PhoneStatus3 { get; set; }
        public Nullable<int> PhoneStatus4 { get; set; }
        public Nullable<int> PhoneStatus5 { get; set; }
        public Nullable<int> PhoneStatus6 { get; set; }
        public Nullable<int> PhoneStatus7 { get; set; }
        public Nullable<int> PhoneStatus8 { get; set; }
        public Nullable<int> PhoneStatus9 { get; set; }
        public Nullable<int> PhoneStatus10 { get; set; }
        public int CurrentPhone { get; set; }
        public string Comments { get; set; }
        public string CustomData1 { get; set; }
        public string CustomData2 { get; set; }
        public string CustomData3 { get; set; }
        public string CallerID { get; set; }
        public string CallerName { get; set; }
        public int BatchNumber { get; set; }
        public string Command { get; set; }
        public int CapturingAgent { get; set; }
        public int LastAgent { get; set; }
        public Nullable<int> LastQCode { get; set; }
        public string CallingHours { get; set; }
        public int leadSource { get; set; }
        public string affinity { get; set; }
        public string leadProvider { get; set; }
        public string campaignName { get; set; }
        public Nullable<DateTime> FirstHandlingDate { get; set; }
        public Nullable<DateTime> LastHandlingDate { get; set; }
        public Nullable<DateTime> ScheduleDate { get; set; }
        public string LoadDescription { get; set; }
        public string connStringCIM;
        public string connStringPresence;

        public bool PresenceDuplicate()
        {
            OutQueuePhone newPhone = new OutQueuePhone();
            if(BatchNumber != 0)
            {
                newPhone = this.GetBatch().GetAwaiter().GetResult();
                this.LoadID = newPhone.LoadID;
            }
            SQLRepository sql = new SQLRepository();
            return sql.PresenceDuplicate(this.SourceID, this.LoadID, this.ServiceID, connStringPresence);
        }
        public async Task<OutQueuePhone> GetBatch()
        {
            try
            {
                if (this.BatchNumber != 0)
                {
                    //if(this.Phone == "" && this.Phone1 != "")
                    //{
                    //    this.Phone = this.Phone1;
                    //}
                    SQLRepository sql = new SQLRepository();
                    return await sql.QueryBatchService(this);
                }
                else
                {
                    return this;
                }
            }
            catch(Exception ex)
            {
                return new OutQueuePhone();
            }

        }



    }
}
