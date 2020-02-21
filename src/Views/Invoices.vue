<template>
    <AllInvoices></AllInvoices>
</template>

<script>
      import AllInvoices from '@/components/AllInvoices'
    export default {
         components: {
            AllInvoices,
        },
        data: function () {
            return {
              
            }
        },
    }

</script>

<style scoped>
    .v-sheet--offset {
        top: -24px;
        position: relative;
    }
</style>
