# ~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~
# Setup Terraform and providers
terraform {

  required_version = ">= 1.0"

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 2.59.0"
    }
  }

  backend "azurerm" {
    # As defined in ../extras/create_remote_backend/main.tf
    resource_group_name  = "Terraform_Backend"
    storage_account_name = "terraformstorageexample"
    container_name       = "terraform-remote-state"
    key                  = "terraform-test.tfstate"
  }
}

provider "azurerm" {
  features {
    key_vault {
      purge_soft_delete_on_destroy = true
    }
  }
  # In case you do not have full permissions uncomment the next line:
  # skip_provider_registration = true
}

provider "azuread" {
  # In case you do not have full permissions uncomment the next line:
  # skip_provider_registration = true
}

# ~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~
# Create the root Resource Group
resource "azurerm_resource_group" "rg" {
  name     = "Baern_Hackt"
  location = "Switzerland North"
  # location = "North Europe"
}

# ~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~^~
# Get client config
data "azurerm_client_config" "current" {}
