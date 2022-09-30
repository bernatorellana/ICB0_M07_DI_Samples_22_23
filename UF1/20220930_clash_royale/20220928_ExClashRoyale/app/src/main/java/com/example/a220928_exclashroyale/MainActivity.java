package com.example.a220928_exclashroyale;

import static com.example.a220928_exclashroyale.model.Card.getCartes;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;

import com.example.a220928_exclashroyale.model.Card;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    RecyclerView rcyCards;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // 1.- Busquem el recycler
        rcyCards = findViewById(R.id.rcyCards);
        // 2.- Assignar un layout al recycler ( vas en horitzontal , vertical o una graella )
        rcyCards.setLayoutManager(new LinearLayoutManager(this));
        rcyCards.hasFixedSize();
        // 3.- Crear llista de Cartes
        List<Card> cartes = Card.getCartes();
        // 4.- Crear adapter
        CardsAdapter adapter = new CardsAdapter(cartes);
        // 5.- Assignar l'adapter al recyclerview
        rcyCards.setAdapter(adapter);
    }
}