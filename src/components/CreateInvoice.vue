<template>

    <div>
        <h1>Skapa ny faktura</h1>
        <br />
        <h3>Kund</h3>
        <v-text-field 
                     
                      label="Kund"
                    placeholder="Sök för att välja kund..."
                      required></v-text-field>
        <br />
        <h3>Produker</h3>
        <v-text-field 
                     
                      label="Produkt"
                      placeholder="Sök för att lägga till produkt..."
                      required></v-text-field>
        <br />
        <br />
        <form>
            <v-text-field v-model="product"
                          :counter="10"
                          label="Product"
                          data-vv-name="product"
                          required></v-text-field>

            <v-text-field v-model="messageText"
                          :counter="10"
                          label="Message"
                          data-vv-name="messageText"
                          required></v-text-field>

            <v-text-field v-model="emailTo"
                          :counter="10"
                          label="Email to"
                          data-vv-name="emailTo"
                          required></v-text-field>


            <v-text-field v-model="emailFrom"
                          :counter="10"
                          label="Email from"
                          data-vv-name="emailFrom"
                          required></v-text-field>


            <v-text-field v-model="price"
                          label="Price"
                          data-vv-name="price"
                          required></v-text-field>
            <v-btn class="mr-4" @click="generatePdf">Generate invoice as PDF</v-btn>
            <v-btn class="mr-4" @click="sendInvoice">Send invoice via E-mail</v-btn>

        </form>
        <br/> <br />
        <br />
    </div>

   
</template>
<script>
    import invoice from '@/services/invoice'
    export default {

        data: () => ({
            product: '',
            messageText: '',
            emailTo: '',
            emailFrom: '',
            price: '',
        }),
        methods: {
            generatePdf() {
                invoice.GeneratePdfInvoice({
                    MessageText: this.messageText,
                    EmailTo: this.emailTo,
                    EmalFrom: this.emailFrom
                });
            },
            sendInvoice() {
                invoice.SendInvoiceViaMail({
                    MessageText: this.messageText,
                    EmailTo: this.emailTo,
                    EmailFrom: this.emailFrom,
                });
            },
        },
    }
</script>
<style scoped>

</style>
