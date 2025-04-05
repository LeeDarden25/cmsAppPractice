<template>
  <div class="formContainer">
    <form class="customer-form" @submit.prevent="onSubmit">
      <div class="row">
        <label for="newCustomer">Name:</label>
          <input type="text" id="newCustomer" v-model="name" />
      </div>
      <div class="row">
        <label for="newCustomerEmail">Email:</label>
        <input type="email" id="newCustomerEmail" v-model="email" />
      </div>
      <div class="row">
        <label for="newCustomerPhone">Phone Number:</label>
        <input type="tel" id="newCustomerPhone" v-model.number="phoneNum"/>
      </div>
      <div class="row">
        <button type="submit">Submit</button>
      </div>
      <p v-for="customer in customers" :key="customer.id">
        <b>* {{customer.id}} | {{ customer.name }} | {{ customer.email }} | {{ customer.phone }}</b>&nbsp;
        <button @click="deleteCustomer(customer.id)">Delete Customer</button>
    </p>
    </form>
  </div>
</template>

<script>
export default {
  name: 'MyCustomer',
  data() {
    return {
      title: 'Customer Form',
      customers:[]
    }
  },
}
</script>