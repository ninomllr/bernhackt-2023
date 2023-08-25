resource "azurerm_container_registry" "acr" {
  name                = "acrbernhackt"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  sku                 = "Premium"
  admin_enabled       = true
}
