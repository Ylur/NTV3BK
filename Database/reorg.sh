#!/bin/bash
# This script reorganizes files to match the desired folder tree.
# Run it from the root (Verkefni) directory.

echo "Starting reorganization..."

########## BLOGAPP ##########
# 1. Fix BlogApp: Remove extra nested Migrations folder.
BLOGAPP_MIGRATIONS="SchoolProjects/BlogApp/BlogApp/Migrations"
if [ -d "$BLOGAPP_MIGRATIONS/Migrations" ]; then
    echo "Moving inner Migrations up in BlogApp..."
    mv "$BLOGAPP_MIGRATIONS/Migrations/"* "$BLOGAPP_MIGRATIONS/"
    rmdir "$BLOGAPP_MIGRATIONS/Migrations"
fi

# (Optional) Remove the top-level Models folder if not needed:
if [ -d "Models" ]; then
    echo "Removing top-level Models folder..."
    rm -r Models
fi

########## SALESORDERS ##########
# 2. Fix SalesOrders: Move contents of "Verkefni 2" up.
SALESORDERS_DIR="SchoolProjects/SalesOrders/SalesOrders"
if [ -d "$SALESORDERS_DIR/Verkefni 2" ]; then
    echo "Moving files from 'Verkefni 2' up in SalesOrders..."
    mv "$SALESORDERS_DIR/Verkefni 2/"* "$SALESORDERS_DIR/"
    rmdir "$SALESORDERS_DIR/Verkefni 2"
fi

# Ensure the Models folder exists in SalesOrders.
mkdir -p "$SALESORDERS_DIR/Models"

# Move model files into the Models folder and rename where needed.
if [ -f "$SALESORDERS_DIR/Customer.cs" ]; then
    echo "Moving Customer.cs into Models..."
    mv "$SALESORDERS_DIR/Customer.cs" "$SALESORDERS_DIR/Models/Customer.cs"
fi

if [ -f "$SALESORDERS_DIR/Orders.cs" ]; then
    echo "Renaming and moving Orders.cs to Order.cs into Models..."
    mv "$SALESORDERS_DIR/Orders.cs" "$SALESORDERS_DIR/Models/Order.cs"
fi

if [ -f "$SALESORDERS_DIR/OrderItem.cs" ]; then
    echo "Moving OrderItem.cs into Models..."
    mv "$SALESORDERS_DIR/OrderItem.cs" "$SALESORDERS_DIR/Models/OrderItem.cs"
fi

if [ -f "$SALESORDERS_DIR/Products.cs" ]; then
    echo "Renaming and moving Products.cs to Product.cs into Models..."
    mv "$SALESORDERS_DIR/Products.cs" "$SALESORDERS_DIR/Models/Product.cs"
fi

echo "Reorganization complete."
