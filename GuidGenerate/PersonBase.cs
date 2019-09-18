
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidGenerate
{
       [GUID("6c030e66-a9fb-452c-a567-4f8465e25740")]
	public class PersonBase 
	{
            [GUID("b0f89e85-0bd4-4bf5-9c0a-0f9817e93050")]
    		private String name;
            [GUID("daba7610-2eb8-4a28-9ce1-db8fad975afe")]
    		private String address;
            [GUID("9330e21b-d318-4974-b0f3-3e5bc5a58b63")]
    		private Int32 age;
            [GUID("2b644304-a1ee-4c46-90e8-4ee8813a83b0")]
    		private Boolean gender;
            [GUID("e078368f-4d61-44df-a69e-1c39fcf79305")]
    		private List<String> list;

		public PersonBase(){}
    
		public String getName() {
        		return name;
        }

		public String getAddress() {
        		return address;
        }

		public Int32 getAge() {
        		return age;
        }

		public Boolean getGender() {
        		return gender;
        }

		public List<String> getList() {
        		return list;
        }


    		public void setName(String newValue) {
        		name = newValue;
        }

    		public void setAddress(String newValue) {
        		address = newValue;
        }

    		public void setAge(Int32 newValue) {
        		age = newValue;
        }

    		public void setGender(Boolean newValue) {
        		gender = newValue;
        }

    		public void setList(List<String> newValue) {
        		list = newValue;
        }

	}
}