
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidGenerate
{
       [GUID("4277f9e5-1f66-4fa1-afc5-c108a6f7150b")]
	public class PersonBase 
	{
            [GUID("ef42cfaa-9914-486a-b7e8-89bf1e960e86")]
    		private String name;
            [GUID("7ff9d779-fe40-49f6-ac99-12c22aab6815")]
    		private String address;
            [GUID("b01666e5-be1b-4d93-a5eb-aa23306bc4aa")]
    		private Int32 age;
            [GUID("458dc3d8-1472-4195-a0a6-3c4af9267fc0")]
    		private Boolean gender;
            [GUID("97b843fc-fcee-49af-9224-04510f52721d")]
    		private List<String> list;

		public PersonBase(){}
    
		public String getname() {
        		return name;
        }

		public String getaddress() {
        		return address;
        }

		public Int32 getage() {
        		return age;
        }

		public Boolean getgender() {
        		return gender;
        }

		public List<String> getlist() {
        		return list;
        }


    		public void setname(String newValue) {
        		name = newValue;
        }

    		public void setaddress(String newValue) {
        		address = newValue;
        }

    		public void setage(Int32 newValue) {
        		age = newValue;
        }

    		public void setgender(Boolean newValue) {
        		gender = newValue;
        }

    		public void setlist(List<String> newValue) {
        		list = newValue;
        }

	}
}