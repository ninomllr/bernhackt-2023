output "linux_web_app_name" {
  value = azurerm_linux_web_app.webapp.name
}

output "app_url" {
  value = "https://${azurerm_linux_web_app.webapp.default_hostname}"
}
