package com.example.a220928_exclashroyale;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.a220928_exclashroyale.model.Card;

import java.util.List;

public class CardsAdapter extends RecyclerView.Adapter<CardsAdapter.ViewHolder> {

    private List<Card> cartes;
    public CardsAdapter( List<Card> cartes) {
        this.cartes = cartes;
    }

    @NonNull
    @Override
    public CardsAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View viewFila = LayoutInflater.from(parent.getContext()).inflate(R.layout.fila, parent, false);
        return new CardsAdapter.ViewHolder(viewFila);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Card actual = cartes.get(position);
        holder.txvId.setText( actual.getId() + "");
        holder.ivFotos.setImageDrawable(getDrawable());
        holder.txvNom.setText( actual.getName());
    }

    @Override
    public int getItemCount() {
        return cartes.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView txvId;
        TextView txvNom;
        ImageView ivFotos;
        public ViewHolder(@NonNull View filaview) {
            super(filaview);
            txvId = filaview.findViewById(R.id.txvId);
            txvNom = filaview.findViewById(R.id.txvNom);
            ivFotos = filaview.findViewById(R.id.ivFotos);
        }
    }
}
