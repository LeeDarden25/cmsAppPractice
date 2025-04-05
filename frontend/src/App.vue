<template>
  <div id="app">
    <header id="header">
      <div class="container">
      </div>
    </header>
    <Customer />
  </div>
</template>

<script src="https://cdnjs.cloudflare.com/ajax/libs/axios/1.8.4/axios.min.js" integrity="sha512-2A1+/TAny5loNGk3RBbk11FwoKXYOMfAK6R7r4CpQH7Luz4pezqEGcfphoNzB7SM4dixUoJsKkBsB6kg+dNE2g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>

<script>
import Customer from './components/Customer.vue'



export default {
  name: 'App',
  components: {
    Customer
  },
    methods:{
        async refreshData(){
            axios.get(API_URL+"api/cmsapp/GetCustomers").then(
                (response)=>{
                    this.customers=response.data;
                }
            )
        },
        async addNewCustomer(){
            var newCustomer = document.getElementById("newCustomer").value;
            var newCustomerEmail = document.getElementById("newCustomerEmail").value;
            var newCustomerPhone = document.getElementById("newCustomerPhone").value;
            const formData = new FormData();
            formData.append("newCustomer", newCustomer);
            formData.append("newCustomerEmail", newCustomerEmail);
            formData.append("newCustomerPhone", newCustomerPhone);


            axios.post(API_URL+"api/cmsapp/AddCustomer", formData).then(
                (response)=>{
                    this.refreshData();
                    alert(response.data);
                }
            )
        },
        async deleteCustomer(id){


            axios.delete(API_URL+"api/cmsapp/DeleteCustomer?id="+id).then(
                (response)=>{
                    this.refreshData();
                    alert(response.data);
                }
            )
        }
    }
}
</script>